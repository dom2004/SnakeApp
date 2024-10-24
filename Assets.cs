using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeApp
{
    public static class Assets
    {
        public readonly static ImageSource Empty = LoadAsset("Empty.png");
        public readonly static ImageSource Food = LoadAsset("Food.png");
        public readonly static ImageSource Body = LoadAsset("Body.png");
        public readonly static ImageSource DeadBody = LoadAsset("DeadBody.png");
        public readonly static ImageSource DeadHead = LoadAsset("DeadHead.png");
        public readonly static ImageSource Head = LoadAsset("Head.png");

        private static ImageSource LoadAsset(string assetPath)
        {
            return new BitmapImage(new Uri($"Assets/{assetPath}", UriKind.Relative));
        }
    }
}
