namespace AegisBornCommon
{
    public enum ParameterCode : short
    {
        /// <summary>
        /// The error code.
        /// </summary>
        ErrorCode = 0,

        /// <summary>
        /// The debug message.
        /// </summary>
        DebugMessage = 1,

        /// <summary>
        /// The player's username
        /// </summary>
        UserName = 10,

        /// <summary>
        /// The player's password
        /// </summary>
        Password = 11,

        /// <summary>
        /// Client key parameter used to establish secure communication.
        /// </summary>
        ClientKey = 16,

        /// <summary>
        /// Server key parameter used to establish secure communication.
        /// </summary>
        ServerKey = 17,

    }
}
