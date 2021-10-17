﻿namespace UAssetAPI.Kismet.Bytecode.Expressions
{
    /// <summary>
    /// A single Kismet bytecode instruction, corresponding to the <see cref="EExprToken.EX_Skip"/> instruction.
    /// </summary>
    public class EX_Skip : Expression
    {
        /// <summary>
        /// The token of this expression.
        /// </summary>
        public override EExprToken Token { get { return EExprToken.EX_Skip; } }

        /// <summary>
        /// The offset to skip to.
        /// </summary>
        public uint CodeOffset;

        /// <summary>
        /// An expression to possibly skip.
        /// </summary>
        public Expression SkipExpression;

        public EX_Skip()
        {

        }

        /// <summary>
        /// Reads out the expression from a BinaryReader.
        /// </summary>
        /// <param name="reader">The BinaryReader to read from.</param>
        public override void Read(AssetBinaryReader reader)
        {
            CodeOffset = reader.ReadUInt32();
            SkipExpression = ExpressionSerializer.ReadExpression(reader);
        }

        /// <summary>
        /// Writes the expression to a BinaryWriter.
        /// </summary>
        /// <param name="writer">The BinaryWriter to write from.</param>
        /// <returns>The length in bytes of the data that was written.</returns>
        public override int Write(AssetBinaryWriter writer)
        {
            writer.Write(CodeOffset);
            ExpressionSerializer.WriteExpression(SkipExpression, writer);
            return 0;
        }
    }
}