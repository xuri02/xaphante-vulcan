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
using SharpVk.NVidia;

namespace SharpVk.Interop.NVidia
{
    /// <summary>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PipelineViewportWScalingStateCreateInfo
    {
        /// <summary>
        ///     The type of this structure
        /// </summary>
        public StructureType SType;

        /// <summary>
        ///     Null or an extension-specific structure
        /// </summary>
        public void* Next;

        /// <summary>
        ///     The enable for viewport W scaling
        /// </summary>
        public Bool32 ViewportWScalingEnable;

        /// <summary>
        ///     The number of viewports used by W scaling and must match the number
        ///     of viewports in the pipeline if viewport W scaling is enabled.
        /// </summary>
        public uint ViewportCount;

        /// <summary>
        ///     An array of ViewportWScalingNV structures which define the W
        ///     scaling parameters for the corresponding viewport. If the viewport
        ///     W scaling state is dynamic, this member is ignored.
        /// </summary>
        public ViewportWScaling* ViewportWScalings;
    }
}