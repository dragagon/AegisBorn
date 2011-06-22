using AegisBornCommon;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

public class EstablishSecureCommunicationOperation : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstablishSecureCommunicationOperation"/> class.
    /// </summary>
    /// <param name="operationRequest">
    /// The operation request.
    /// </param>
    public EstablishSecureCommunicationOperation(OperationRequest operationRequest)
        : base(operationRequest)
    {
    }

    /// <summary>
    /// Gets or sets the clients public key.
    /// </summary>
    [RequestParameter(Code = (short)ParameterCode.ClientKey, IsOptional = false)]
    public byte[] ClientKey { get; set; }

    /// <summary>
    /// Gets or sets the servers public key.
    /// </summary>
    [ResponseParameter(Code = (short)ParameterCode.ServerKey, IsOptional = false)]
    public byte[] ServerKey { get; set; }
}
