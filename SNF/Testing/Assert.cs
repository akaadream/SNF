namespace SNF.Testing
{
    internal static class Assert
    {
        internal static void Check(bool condition, string message)
        {
            if (condition)
            {
                throw new SNFException(message);
            }
        }
    }
}
