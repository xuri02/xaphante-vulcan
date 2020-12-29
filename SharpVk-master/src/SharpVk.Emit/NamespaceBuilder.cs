﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpVk.Emit
{
    public class NamespaceBuilder
        : BlockBuilder
    {
        private bool hasFirstElement;

        public NamespaceBuilder(IndentedTextWriter writer)
            : base(writer)
        {
        }

        public void EmitType(TypeKind kind,
            string name,
            Action<TypeBuilder> type,
            AccessModifier accessModifier = AccessModifier.Internal,
            IEnumerable<string> baseTypes = null,
            TypeModifier modifiers = TypeModifier.None,
            IEnumerable<string> summary = null,
            Action<DocBuilder> docs = null,
            IEnumerable<string> attributes = null)
        {
            EmitTypePreamble(summary, docs, attributes);

            writer.WriteLine($"{accessModifier.Emit()} {RenderTypeModifiers(modifiers)}{kind.ToString().ToLowerInvariant()} {name}");

            if (baseTypes != null && baseTypes.Any())
            {
                writer.IncreaseIndent();
                writer.WriteLine($": {string.Join(", ", baseTypes)}");
                writer.DecreaseIndent();
            }

            using (var builder = new TypeBuilder(writer.GetSubWriter(), name))
            {
                type(builder);
            }
        }

        public void EmitDelegate(string type,
            string name,
            AccessModifier accessModifier = AccessModifier.Internal,
            TypeModifier modifiers = TypeModifier.None,
            Action<ParameterBuilder> parameters = null,
            IEnumerable<string> summary = null,
            Action<DocBuilder> docs = null,
            IEnumerable<string> attributes = null)
        {
            EmitTypePreamble(summary, docs, attributes);

            var parameterList = parameters != null
                ? ParameterBuilder.Apply(parameters)
                : "";

            writer.WriteLine($"{accessModifier.Emit()} {RenderTypeModifiers(modifiers)}delegate {type} {name}({parameterList});");
        }

        public void EmitEnum(string name,
            Action<EnumBuilder> @enum,
            AccessModifier accessModifier = AccessModifier.Internal,
            IEnumerable<string> summary = null,
            Action<DocBuilder> docs = null,
            IEnumerable<string> attributes = null)
        {
            EmitTypePreamble(summary, docs, attributes);

            writer.WriteLine($"{accessModifier.Emit()} enum {name}");
            using (var builder = new EnumBuilder(writer.GetSubWriter()))
            {
                @enum(builder);
            }
        }

        private void EmitTypePreamble(IEnumerable<string> summary, Action<DocBuilder> docs, IEnumerable<string> attributes)
        {
            if (hasFirstElement)
                writer.WriteLine();
            else
                hasFirstElement = true;

            var docsBuilder = new DocBuilder(writer.GetSubWriter(), summary);

            docs?.Invoke(docsBuilder);

            if (attributes != null)
                foreach (var attributeName in attributes)
                    writer.WriteLine($"[{attributeName}]");
        }

        private string RenderTypeModifiers(TypeModifier modifiers)
        {
            var builder = new StringBuilder();

            foreach (TypeModifier value in Enum.GetValues(typeof(TypeModifier)))
                if (value != TypeModifier.None && modifiers.HasFlag(value))
                    builder.Append(value.ToString().ToLowerInvariant() + " ");

            return builder.ToString();
        }
    }
}