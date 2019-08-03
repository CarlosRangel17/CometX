namespace CometX.NETCore.Entities.GenericEntity
{
    public class Lexicon
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Lexicon()
        {
            Key = "";
            Value = "";
        }

        public Lexicon(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
