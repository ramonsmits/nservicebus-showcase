namespace Store.ContentManagement
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<MsmqTransport>
    {
        public void Customize(BusConfiguration configuration)
        {
            System.Console.Title = "Content Management";
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Store") && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Store") && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Store") && t.Namespace.EndsWith("RequestResponse"));
            configuration.RijndaelEncryptionService();
        }
    }
}