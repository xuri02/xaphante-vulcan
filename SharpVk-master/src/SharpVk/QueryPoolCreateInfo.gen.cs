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
    ///     Structure specifying parameters of a newly created query pool.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct QueryPoolCreateInfo
    {
        /// <summary>
        ///     Reserved for future use.
        /// </summary>
        public QueryPoolCreateFlags? Flags
        {
            get;
            set;
        }

        /// <summary>
        ///     The type of queries managed by the pool.
        /// </summary>
        public QueryType QueryType
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public uint QueryCount
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public QueryPipelineStatisticFlags? PipelineStatistics
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal unsafe void MarshalTo(Interop.QueryPoolCreateInfo* pointer)
        {
            pointer->SType = StructureType.QueryPoolCreateInfo;
            pointer->Next = null;
            if (Flags != null)
                pointer->Flags = Flags.Value;
            else
                pointer->Flags = default;
            pointer->QueryType = QueryType;
            pointer->QueryCount = QueryCount;
            if (PipelineStatistics != null)
                pointer->PipelineStatistics = PipelineStatistics.Value;
            else
                pointer->PipelineStatistics = default;
        }
    }
}