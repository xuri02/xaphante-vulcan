﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using GlmSharp;
using SharpVk;
using SharpVk.Khronos;
using vulcan_01.Render;

namespace vulcan_01
{
    internal partial class Program
    {
        private static async Task Main(string[] args)
        {
            var pg = new Program();
            var r = new Random();
            var fun = new Thread(() =>
            {
                Thread.Sleep(2000);
                var i = 0;
                while (true)
                {
                    i++;

                    Thread.Sleep(1000);
                    var i1 = i;
                    //pg.applicationQueue.Enqueue(delegate
                    //{
                    //pg.RecreateSwapChain();
                    var bi = pg.bufferManager.Buffers[0];

                    {
                        var size = pg.indices.Length;
                        var ne = new ushort[pg.indices.Length];
                        for (int j = 0; j < ne.Length; j++)
                        {
                            ne[j] = (ushort)r.Next(0, pg.vertices.Length);
                        }

                        var bs = pg.bufferManager.CreateCopyBuffer(ref ne, out var sb, out var sm);

                        pg.bufferManager.CopyBuffer(sb, bi.IndexBuffer, bs);

                        sb.Dispose();
                        sm.Free();

                        bi.IndexBufferMemory.Unmap();
                    }
                    {
                        float SingXv(float def)
                        {
                            var si = MathF.Abs(MathF.Sin(i1 / 100f + def * (MathF.PI / 2)));
                            return si;
                        }

                        Vertex[] vn = new Vertex[pg.vertices.Length];
                        for (int j = 0; j < vn.Length; j++)
                        {
                            vn[j] = new(new vec3((float)(r.NextDouble() * 2 - 1), (float)(r.NextDouble() * 2 - 1), (float)(r.NextDouble() * 2 - 1)), new((float)(r.NextDouble()), (float)(r.NextDouble()), (float)(r.NextDouble())));
                        }

                        var bs = pg.bufferManager.CreateCopyBuffer(ref vn, out var sb, out var sm);

                        pg.bufferManager.CopyBuffer(sb, bi.VertexBuffer, bs);

                        sb.Dispose();
                        sm.Free();

                        bi.IndexBufferMemory.Unmap();
                    }
                    //});
                    pg.applicationQueue.Enqueue(async () => pg.RecreateSwapChain());
                }
            });
            fun.Start();

            pg.Run();
            Environment.Exit(0);
        }

        private Camera c = new Camera();

        private void Run()
        {
            InitWindow();
            InitVulkan();

            initialTimestamp = Stopwatch.GetTimestamp();
            window.MainLoop();
            Cleanup();
        }

        private void InitWindow()
        {
            window = new PlatformWindow();
            window.InitWindow(SurfaceWidth, SurfaceHeight);
            window.OnFrame += OnFrame;
            window.OnResize += delegate
            {
                RecreateSwapChain();
            };
        }

        private void OnFrame(object? sender, EventArgs e)
        {
            UpdateApplication();
            UpdateUniformBuffer();
            DrawFrame();
        }

        private void InitVulkan()
        {
            CreateBufferManager();

            CreateInstance();
            window.CreateSurface(instance ?? throw new InvalidOperationException("Instance was not Created"));
            CreateDevice();
            CreateSwapChain();
            CreateImageViews();
            CreateRenderPass();
            CreateDescriptorSetLayout();
            CreateShaderModules();
            CreateGraphicsPipeline();
            CreateCommandPools();
            CreateDepthResources();
            CreateFrameBuffers();
            CreateTextureImage();
            CreateTextureImageView();
            CreateTextureSampler();
            bufferManager.AddBuffer(vertices, indices);
            bufferManager.CreateUniformBuffer();
            CreateDescriptorPool();
            CreateDescriptorSet();
            CreateCommandBuffers();
            CreateSemaphores();
        }

        private void DrawFrame()
        {
            if (swapChain == null) throw NotCreated(swapChain, nameof(swapChain));
            if (commandBuffers == null) throw NotCreated(commandBuffers, nameof(commandBuffers));

            var nextImage = swapChain.AcquireNextImage(uint.MaxValue, imageAvailableSemaphore, null);

            graphicsQueue.Submit(new SubmitInfo
            {
                CommandBuffers = new[]
                {
                    commandBuffers[nextImage]
                },
                SignalSemaphores = new[]
                {
                    renderFinishedSemaphore
                },
                WaitDestinationStageMask = new[]
                {
                    PipelineStageFlags.ColorAttachmentOutput
                },
                WaitSemaphores = new[]
                {
                    imageAvailableSemaphore
                }
            }, null);

            presentQueue.Present(renderFinishedSemaphore, swapChain, nextImage, new Result[1]);
        }

        private void UpdateUniformBuffer()
        {
            long currentTimestamp = Stopwatch.GetTimestamp();

            float totalTime = (currentTimestamp - initialTimestamp) / (float)Stopwatch.Frequency;

            var ubo = new UniformBufferObject
            {
                Model = mat4.Rotate((float)Math.Sin(totalTime) * (float)Math.PI, vec3.UnitZ),
                View = c.matrices.view, //mat4.LookAt(new(2), vec3.Zero, vec3.UnitZ),
                Proj = c.matrices.perspective //mat4.Perspective((float)Math.PI / 4f, swapChainExtent.Width / (float)swapChainExtent.Height, 0.1f, 10)
            };

            ubo.Proj[1, 1] *= -1;

            uint uboSize = (uint)Unsafe.SizeOf<UniformBufferObject>();

            IntPtr memoryBuffer = bufferManager.UniformStagingBufferMemory.Map(0, uboSize, MemoryMapFlags.None);

            Marshal.StructureToPtr(ubo, memoryBuffer, false);

            bufferManager.UniformStagingBufferMemory.Unmap();

            bufferManager.CopyBuffer(bufferManager.UniformStagingBuffer, bufferManager.UniformBuffer, uboSize);
        }

        private readonly Queue<Action> applicationQueue = new();

        private void UpdateApplication()
        {
            if (applicationQueue.TryDequeue(out var action))
                action.Invoke();
        }
    }
}
