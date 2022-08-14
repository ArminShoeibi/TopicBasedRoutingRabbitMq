//using EasyNetQ.Internals;
//using EasyNetQ;
//using System.Buffers;

//namespace TopicBasedRoutingRabbitMq.Shared;

//public class SystemTextJsonSerializer : ISerializer
//{
//    public object BytesToMessage(Type messageType, in ReadOnlyMemory<byte> bytes)
//    {
//        return System.Text.Json.JsonSerializer.Deserialize(bytes.Span, returnType: messageType);
//    }

//    public IMemoryOwner<byte> MessageToBytes(Type messageType, object message)
//    {
//        using ArrayPooledMemoryStream arrayPooledMemoryStream = new();
//        System.Text.Json.JsonSerializer.Serialize(arrayPooledMemoryStream, message, messageType);
//        return arrayPooledMemoryStream;
//    }
//}