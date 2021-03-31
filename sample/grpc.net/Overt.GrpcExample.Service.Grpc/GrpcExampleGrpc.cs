// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GrpcExample.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Overt.GrpcExample.Service.Grpc {
  public static partial class GrpcExampleService
  {
    static readonly string __ServiceName = "Overt.GrpcExample.Service.Grpc.GrpcExampleService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.RequestModel> __Marshaller_Overt_GrpcExample_Service_Grpc_RequestModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.RequestModel.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.ResponseModel> __Marshaller_Overt_GrpcExample_Service_Grpc_ResponseModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.ResponseModel.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.AskRequest> __Marshaller_Overt_GrpcExample_Service_Grpc_AskRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.AskRequest.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.AskResponse> __Marshaller_Overt_GrpcExample_Service_Grpc_AskResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.AskResponse.Parser));

    static readonly grpc::Method<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel> __Method_GetName = new grpc::Method<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetName",
        __Marshaller_Overt_GrpcExample_Service_Grpc_RequestModel,
        __Marshaller_Overt_GrpcExample_Service_Grpc_ResponseModel);

    static readonly grpc::Method<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse> __Method_Ask = new grpc::Method<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Ask",
        __Marshaller_Overt_GrpcExample_Service_Grpc_AskRequest,
        __Marshaller_Overt_GrpcExample_Service_Grpc_AskResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Overt.GrpcExample.Service.Grpc.GrpcExampleReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GrpcExampleService</summary>
    [grpc::BindServiceMethod(typeof(GrpcExampleService), "BindService")]
    public abstract partial class GrpcExampleServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Overt.GrpcExample.Service.Grpc.AskResponse> Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for GrpcExampleService</summary>
    public partial class GrpcExampleServiceClient : grpc::ClientBase<GrpcExampleServiceClient>
    {
      /// <summary>Creates a new client for GrpcExampleService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GrpcExampleServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for GrpcExampleService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GrpcExampleServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GrpcExampleServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GrpcExampleServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Overt.GrpcExample.Service.Grpc.ResponseModel GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.ResponseModel GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetName, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetNameAsync(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetNameAsync(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetName, null, options, request);
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.AskResponse Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Ask(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.AskResponse Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Ask, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.AskResponse> AskAsync(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AskAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.AskResponse> AskAsync(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Ask, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GrpcExampleServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GrpcExampleServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GrpcExampleServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetName, serviceImpl.GetName)
          .AddMethod(__Method_Ask, serviceImpl.Ask).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcExampleServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel>(serviceImpl.GetName));
      serviceBinder.AddMethod(__Method_Ask, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse>(serviceImpl.Ask));
    }

  }
  public static partial class GrpcExampleService1
  {
    static readonly string __ServiceName = "Overt.GrpcExample.Service.Grpc.GrpcExampleService1";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.RequestModel> __Marshaller_Overt_GrpcExample_Service_Grpc_RequestModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.RequestModel.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.ResponseModel> __Marshaller_Overt_GrpcExample_Service_Grpc_ResponseModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.ResponseModel.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.AskRequest> __Marshaller_Overt_GrpcExample_Service_Grpc_AskRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.AskRequest.Parser));
    static readonly grpc::Marshaller<global::Overt.GrpcExample.Service.Grpc.AskResponse> __Marshaller_Overt_GrpcExample_Service_Grpc_AskResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Overt.GrpcExample.Service.Grpc.AskResponse.Parser));

    static readonly grpc::Method<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel> __Method_GetName = new grpc::Method<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetName",
        __Marshaller_Overt_GrpcExample_Service_Grpc_RequestModel,
        __Marshaller_Overt_GrpcExample_Service_Grpc_ResponseModel);

    static readonly grpc::Method<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse> __Method_Ask = new grpc::Method<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Ask",
        __Marshaller_Overt_GrpcExample_Service_Grpc_AskRequest,
        __Marshaller_Overt_GrpcExample_Service_Grpc_AskResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Overt.GrpcExample.Service.Grpc.GrpcExampleReflection.Descriptor.Services[1]; }
    }

    /// <summary>Base class for server-side implementations of GrpcExampleService1</summary>
    [grpc::BindServiceMethod(typeof(GrpcExampleService1), "BindService")]
    public abstract partial class GrpcExampleService1Base
    {
      public virtual global::System.Threading.Tasks.Task<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Overt.GrpcExample.Service.Grpc.AskResponse> Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for GrpcExampleService1</summary>
    public partial class GrpcExampleService1Client : grpc::ClientBase<GrpcExampleService1Client>
    {
      /// <summary>Creates a new client for GrpcExampleService1</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GrpcExampleService1Client(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for GrpcExampleService1 that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GrpcExampleService1Client(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GrpcExampleService1Client() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GrpcExampleService1Client(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Overt.GrpcExample.Service.Grpc.ResponseModel GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.ResponseModel GetName(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetName, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetNameAsync(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.ResponseModel> GetNameAsync(global::Overt.GrpcExample.Service.Grpc.RequestModel request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetName, null, options, request);
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.AskResponse Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Ask(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Overt.GrpcExample.Service.Grpc.AskResponse Ask(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Ask, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.AskResponse> AskAsync(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AskAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Overt.GrpcExample.Service.Grpc.AskResponse> AskAsync(global::Overt.GrpcExample.Service.Grpc.AskRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Ask, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GrpcExampleService1Client NewInstance(ClientBaseConfiguration configuration)
      {
        return new GrpcExampleService1Client(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GrpcExampleService1Base serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetName, serviceImpl.GetName)
          .AddMethod(__Method_Ask, serviceImpl.Ask).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcExampleService1Base serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Overt.GrpcExample.Service.Grpc.RequestModel, global::Overt.GrpcExample.Service.Grpc.ResponseModel>(serviceImpl.GetName));
      serviceBinder.AddMethod(__Method_Ask, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Overt.GrpcExample.Service.Grpc.AskRequest, global::Overt.GrpcExample.Service.Grpc.AskResponse>(serviceImpl.Ask));
    }

  }
}
#endregion
