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
using System.Runtime.InteropServices;

namespace SharpVk.MoltenVk
{
    /// <summary>
    ///     Structure specifying parameters of a newly created iOS surface object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IosSurfaceCreateInfo
    {
        /// <summary>
        ///     Reserved for future use.
        /// </summary>
        public IosSurfaceCreateFlags? Flags
        {
            get;
            set;
        }

        /// <summary>
        ///     A reference to a UIView object which will display this surface.
        ///     This UIView must be backed by a CALayer instance of type
        ///     CAMetalLayer.
        /// </summary>
        public IntPtr View
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal unsafe void MarshalTo(Interop.MoltenVk.IosSurfaceCreateInfo* pointer)
        {
            pointer->SType = StructureType.IosSurfaceCreateInfo;
            pointer->Next = null;
            if (Flags != null)
                pointer->Flags = Flags.Value;
            else
                pointer->Flags = default;
            pointer->View = View.ToPointer();
        }
    }
}
