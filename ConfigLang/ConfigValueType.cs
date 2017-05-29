namespace ConfigLang
{
    public enum ConfigValueType
    {
        /// <summary>
        /// No defined value
        /// </summary>
        NULL,
        Boolean,
        /// <summary>
        /// 64-bit float
        /// </summary>
        Float,
        /// <summary>
        /// 64-bit int
        /// </summary>
        Int,
        /// <summary>
        /// UTF-16 string
        /// </summary>
        String
    }
}