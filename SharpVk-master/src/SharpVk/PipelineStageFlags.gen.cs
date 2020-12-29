// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2020
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;

namespace SharpVk
{
    /// <summary>
    ///     Bitmask specifying pipeline stages.
    /// </summary>
    [Flags]
    public enum PipelineStageFlags
    {
        /// <summary>
        /// </summary>
        None = 0,

        /// <summary>
        ///     Stage of the pipeline where any commands are initially received by
        ///     the queue.
        /// </summary>
        TopOfPipe = 1 << 0,

        /// <summary>
        ///     Stage of the pipeline where Draw/DispatchIndirect data structures
        ///     are consumed. This stage also includes reading commands written by
        ///     flink:vkCmdProcessCommandsNVX.
        /// </summary>
        DrawIndirect = 1 << 1,

        /// <summary>
        ///     Stage of the pipeline where vertex and index buffers are consumed.
        /// </summary>
        VertexInput = 1 << 2,

        /// <summary>
        ///     Vertex shader stage.
        /// </summary>
        VertexShader = 1 << 3,

        /// <summary>
        ///     Tessellation control shader stage.
        /// </summary>
        TessellationControlShader = 1 << 4,

        /// <summary>
        ///     Tessellation evaluation shader stage.
        /// </summary>
        TessellationEvaluationShader = 1 << 5,

        /// <summary>
        ///     Geometry shader stage.
        /// </summary>
        GeometryShader = 1 << 6,

        /// <summary>
        ///     Fragment shader stage.
        /// </summary>
        FragmentShader = 1 << 7,

        /// <summary>
        ///     Stage of the pipeline where early fragment tests (depth and stencil
        ///     tests before fragment shading) are performed. This stage also
        ///     includes subpass load operations for framebuffer attachments with a
        ///     depth/stencil format.
        /// </summary>
        EarlyFragmentTests = 1 << 8,

        /// <summary>
        ///     Stage of the pipeline where late fragment tests (depth and stencil
        ///     tests after fragment shading) are performed. This stage also
        ///     includes subpass store operations for framebuffer attachments with
        ///     a depth/stencil format.
        /// </summary>
        LateFragmentTests = 1 << 9,

        /// <summary>
        ///     Stage of the pipeline after blending where the final color values
        ///     are output from the pipeline. This stage also includes subpass load
        ///     and store operations and multisample resolve operations for
        ///     framebuffer attachments with a color format.
        /// </summary>
        ColorAttachmentOutput = 1 << 10,

        /// <summary>
        ///     Execution of a compute shader.
        /// </summary>
        ComputeShader = 1 << 11,

        /// <summary>
        ///     Execution of copy commands. This includes the operations resulting
        ///     from all copy commands, clear commands (with the exception of
        ///     flink:vkCmdClearAttachments), and flink:vkCmdCopyQueryPoolResults.
        /// </summary>
        Transfer = 1 << 12,

        /// <summary>
        ///     Final stage in the pipeline where operations generated by all
        ///     commands complete execution.
        /// </summary>
        BottomOfPipe = 1 << 13,

        /// <summary>
        ///     A pseudo-stage indicating execution on the host of reads/writes of
        ///     device memory. This stage is not invoked by any commands recorded
        ///     in a command buffer.
        /// </summary>
        Host = 1 << 14,

        /// <summary>
        ///     Execution of all graphics pipeline stages. Equivalent to the
        ///     logical or of:
        /// </summary>
        AllGraphics = 1 << 15,

        /// <summary>
        ///     All stages supported on the queue
        /// </summary>
        AllCommands = 1 << 16,

        /// <summary>
        /// </summary>
        Reserved27 = 1 << 27,

        /// <summary>
        /// </summary>
        Reserved26 = 1 << 26,

        /// <summary>
        /// </summary>
        TransformFeedback = 1 << 24,

        /// <summary>
        /// </summary>
        ConditionalRendering = 1 << 18,

        /// <summary>
        ///     Stage of the pipeline where device-side generation of commands via
        ///     flink:vkCmdProcessCommandsNVX is handled.
        /// </summary>
        CommandProcess = 1 << 17,

        /// <summary>
        /// </summary>
        ShadingRateImage = 1 << 22,

        /// <summary>
        /// </summary>
        RayTracingShader = 1 << 21,

        /// <summary>
        /// </summary>
        AccelerationStructureBuild = 1 << 25,

        /// <summary>
        /// </summary>
        TaskShader = 1 << 19,

        /// <summary>
        /// </summary>
        MeshShader = 1 << 20,

        /// <summary>
        ///     Specifies the stage of the pipeline where the fragment density map
        ///     is read to generate the fragment areas.
        /// </summary>
        FragmentDensityProcess = 1 << 23
    }
}