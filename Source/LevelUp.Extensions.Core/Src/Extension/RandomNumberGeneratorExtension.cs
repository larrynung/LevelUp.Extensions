using System;
using System.Security.Cryptography;

    /// <summary>
    /// 
    /// </summary>
    public static class RandomNumberGeneratorExtension
    {
        #region Methods
        /// <summary>
        /// 產生一個非負數的亂數
        /// </summary>
        public static int Next(this RandomNumberGenerator rng)
        {
            if (rng == null)
                throw new ArgumentNullException("rng");

            var rb = new byte[4];

            rng.GetBytes(rb);

            int value = BitConverter.ToInt32(rb, 0);
            return (value < 0) ? -value : value;
        }

        /// <summary>
        /// 產生一個非負數且最大值 max 以下的亂數
        /// </summary>
        /// <param name="max">最大值</param>
        public static int Next(this RandomNumberGenerator rng, int max)
        {
            return Next(rng) % (max + 1);
        }

        /// <summary>
        /// 產生一個非負數且最小值在 min 以上最大值在 max 以下的亂數
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public static int Next(this RandomNumberGenerator rng, int min, int max)
        {
            return Next(rng, max - min) + min;
        }
        #endregion Methods
    }