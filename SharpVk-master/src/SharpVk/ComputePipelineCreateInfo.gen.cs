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

using System.Runtime.InteropServices;

namespace SharpVk
{
    /// <summary>
    ///     Structure specifying parameters of a newly created compute pipeline.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ComputePipelineCreateInfo
    {
        /// <summary>
        ///     flags provides options for pipeline creation, and is of type
        ///     PipelineCreateFlagBits.
        /// </summary>
        public PipelineCreateFlags? Flags
        {
            get;
            set;
        }

        /// <summary>
        ///     A PipelineShaderStageCreateInfo describing the compute shader.
        /// </summary>
        public PipelineShaderStageCreateInfo Stage
        {
            get;
            set;
        }

        /// <summary>
        ///     The description of binding locations used by both the pipeline and
        ///     descriptor sets used with the pipeline.
        /// </summary>
        public PipelineLayout Layout
        {
            get;
            set;
        }

        /// <summary>
        ///     A pipeline to derive from
        /// </summary>
        public Pipeline BasePipelineHandle
        {
            get;
            set;
        }

        /// <summary>
        ///     An index into the pCreateInfos parameter to use as a pipeline to
        ///     derive from
        /// </summary>
        public int BasePipelineIndex
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal unsafe void MarshalTo(Interop.ComputePipelineCreateInfo* pointer)
        {
            pointer->SType = StructureType.ComputePipelineCreateInfo;
            pointer->Next = null;
            if (Flags != null)
                pointer->Flags = Flags.Value;
            else
                pointer->Flags = default;
            Stage.MarshalTo(&pointer->Stage);
            pointer->Layout = Layout?.Handle ?? default(Interop.PipelineLayout);
            pointer->BasePipelineHandle = BasePipelineHandle?.Handle ?? default(Interop.Pipeline);
            pointer->BasePipelineIndex = BasePipelineIndex;
        }
    }
}
