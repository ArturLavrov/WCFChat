namespace ChatBL
{
    public  class Context
    {
        private readonly IAbstractAlghoritm _abstractAlghoritm;
        public Context(IAbstractAlghoritm someAlghoritm)
        {
            _abstractAlghoritm = someAlghoritm;
        }

        public string ContextEncoding(string text,int k)
        {
            return _abstractAlghoritm.Encoding(text,k);
        }

        public string ContextDecoding(string text,int k)
        {
           return _abstractAlghoritm.Decoding(text, k);
        }
    }
}
