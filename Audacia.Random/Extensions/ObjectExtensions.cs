namespace Audacia.Random.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly System.Random SysRandom = new System.Random();

        public static T OrDefault<T>(this T @object) => @object.OrDefault(50);

        public static T OrDefault<T>(this T @object, int probability)
        {
            var percent = SysRandom.Next(1, 101);
            return percent < probability
                ? default(T) : @object;
        }

        public static T OrNull<T>(this T @object) where T : class => @object.OrNull(50);

        public static T OrNull<T>(this T @object, int probability) where T : class
        {
            var percent = SysRandom.Next(1, 101);
            return percent < probability
                ? null : @object;
        }
    }
}