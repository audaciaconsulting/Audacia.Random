namespace Audacia.Random.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly System.Random SysRandom = new System.Random();

        public static T OrDefault<T>(this T target) => target.OrDefault(50);

        public static T OrDefault<T>(this T target, int probability)
        {
            var percent = SysRandom.Next(1, 101);
            return percent < probability
                ? default(T) : target;
        }

        public static T OrNull<T>(this T target) where T : class => target.OrNull(50);

        public static T OrNull<T>(this T target, int probability) where T : class
        {
            var percent = SysRandom.Next(1, 101);
            return percent < probability
                ? null : target;
        }
    }
}