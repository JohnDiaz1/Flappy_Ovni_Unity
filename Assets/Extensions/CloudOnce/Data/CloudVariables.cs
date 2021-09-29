// <copyright file="CloudVariables.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using CloudPrefs;

    /// <summary>
    /// Provides access to cloud variables registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class CloudVariables
    {
        private static readonly CloudInt s_highScore = new CloudInt("HighScore", PersistenceType.Highest, 0);

        public static int HighScore
        {
            get { return s_highScore.Value; }
            set { s_highScore.Value = value; }
        }

        private static readonly CloudInt s_ads = new CloudInt("Ads", PersistenceType.Latest, 0);

        public static int Ads
        {
            get { return s_ads.Value; }
            set { s_ads.Value = value; }
        }
    }
}
