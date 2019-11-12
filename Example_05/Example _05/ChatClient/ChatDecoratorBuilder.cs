namespace Example__05.ChatClient
{
    public class ChatDecoratorBuilder
    {
        private IChatClient _chatClient;

        public ChatDecoratorBuilder(IChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public ChatDecoratorBuilder WithTextCiphering()
        {
            _chatClient = new TextCipheringDecorator(_chatClient);
            return this;
        }

        public ChatDecoratorBuilder WithNameHiding()
        {
            _chatClient = new NameHidingDecorator(_chatClient);
            return this;
        }

        public IChatClient Build()
        {
            return _chatClient;
        }
    }
}
