using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeApp
{
    public static class Assets
    {
        public readonly static ImageSource _Empty = LoadAsset("Empty.png");
        public readonly static ImageSource _Food = LoadAsset("Food.png");
        public readonly static ImageSource _Body = LoadAsset("Body.png");
        public readonly static ImageSource _DeadBody = LoadAsset("DeadBody.png");
        public readonly static ImageSource _DeadHead = LoadAsset("DeadHead.png");
        public readonly static ImageSource _Head = LoadAsset("Head.png");

        private static ImageSource LoadAsset(string assetPath)
        {
            return new BitmapImage(new Uri($"Assets/{assetPath}", UriKind.Relative));
        }
    }
}
