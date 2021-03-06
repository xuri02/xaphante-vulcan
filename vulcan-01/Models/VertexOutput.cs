﻿using GlmSharp;
using SharpVk.Shanq;
using SharpVk.Spirv;

namespace vulcan_01
{
    internal struct VertexOutput
    {
        [Location(0)] public vec3 Colour;

        [BuiltIn(BuiltIn.Position), Location(1)] public vec4 Position;
    }
}
