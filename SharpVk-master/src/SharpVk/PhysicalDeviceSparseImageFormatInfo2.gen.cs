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
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceSparseImageFormatInfo2
    {
        /// <summary>
        /// </summary>
        public Format Format
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public ImageType Type
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public SampleCountFlags Samples
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public ImageUsageFlags Usage
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public ImageTiling Tiling
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal unsafe void MarshalTo(Interop.PhysicalDeviceSparseImageFormatInfo2* pointer)
        {
            pointer->SType = StructureType.PhysicalDeviceSparseImageFormatInfo2Version;
            pointer->Next = null;
            pointer->Format = Format;
            pointer->Type = Type;
            pointer->Samples = Samples;
            pointer->Usage = Usage;
            pointer->Tiling = Tiling;
        }

        /// <summary>
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal static unsafe PhysicalDeviceSparseImageFormatInfo2 MarshalFrom(Interop.PhysicalDeviceSparseImageFormatInfo2* pointer)
        {
            var result = default(PhysicalDeviceSparseImageFormatInfo2);
            result.Format = pointer->Format;
            result.Type = pointer->Type;
            result.Samples = pointer->Samples;
            result.Usage = pointer->Usage;
            result.Tiling = pointer->Tiling;
            return result;
        }
    }
}