namespace AegisBornCommon
{
    public enum OperationCode : short
    {
        /// <summary>
        /// The nil (nothing).
        /// </summary>
        Nil = 0,

        /// <summary>
        /// Login to the server
        /// </summary>
        Login = 10,

        /// <summary>
        /// Code for exchanging keys using PhotonPeer.OpExchangeKeysForEncryption
        /// </summary>
        ExchangeKeysForEncryption = 95,
    }
}
