﻿using System;

namespace BSOA.Demo
{
    public static class Friendly
    {
        public const double Kilobyte = 1024;
        public const double Megabyte = 1024 * 1024;
        public const double Gigabyte = 1024 * 1024 * 1024;

        public static string Rate(long sizeInBytes, TimeSpan elapsedTime)
        {
            return $"{Size((long)(sizeInBytes / elapsedTime.TotalSeconds))}/s";
        }

        public static string Size(long sizeInBytes)
        {
            if (sizeInBytes < Kilobyte)
            {
                return $"{sizeInBytes:n0} b";
            }
            else if (sizeInBytes < 10 * Kilobyte)
            {
                return $"{sizeInBytes / Kilobyte:n2} KB";
            }
            else if (sizeInBytes < 100 * Kilobyte)
            {
                return $"{sizeInBytes / Kilobyte:n1} KB";
            }
            else if (sizeInBytes < Megabyte)
            {
                return $"{sizeInBytes / Kilobyte:n0} KB";
            }
            else if (sizeInBytes < 10 * Megabyte)
            {
                return $"{sizeInBytes / Megabyte:n2} MB";
            }
            else if (sizeInBytes < 100 * Megabyte)
            {
                return $"{sizeInBytes / Megabyte:n1} MB";
            }
            else if (sizeInBytes < Gigabyte)
            {
                return $"{sizeInBytes / Megabyte:n0} MB";
            }
            else if (sizeInBytes < 10 * Gigabyte)
            {
                return $"{sizeInBytes / Gigabyte:n2} GB";
            }
            else if (sizeInBytes < 100 * Gigabyte)
            {
                return $"{sizeInBytes / Gigabyte:n1} GB";
            }
            else
            {
                return $"{sizeInBytes / Gigabyte:n0} GB";
            }
        }

        public static string Time(TimeSpan elapsed)
        {
            double seconds = elapsed.TotalSeconds;
            if (seconds < 1)
            {
                return $"{elapsed.TotalMilliseconds:n0} ms";
            }
            else if (seconds < 10)
            {
                return $"{seconds:n2} s";
            }
            else if (seconds < 100)
            {
                return $"{seconds:n1} s";
            }
            else
            {
                return $"{(seconds / 60):n1} min";
            }
        }

        public static string Percentage(double numerator, double denominator)
        {
            if (denominator == 0.0) { return "NaN"; }
            if (numerator < 0.0 || denominator < 0.0 || numerator > denominator) { return "Invalid"; }

            double ratio = numerator / denominator;
            if (ratio < 0.01)
            {
                return $"{ratio:p2}";
            }
            else if (ratio < 0.10)
            {
                return $"{ratio:p1}";
            }
            else
            {
                return $"{ratio:p0}";
            }
        }

        public static void HighlightLine(params string[] values)
        {
            ConsoleColor normal = Console.ForegroundColor;

            for (int i = 0; i < values.Length; ++i)
            {
                Console.Write(values[i]);
                Console.ForegroundColor = (i % 2 == 0 ? ConsoleColor.Green : normal);
            }

            Console.WriteLine();
            Console.ForegroundColor = normal;
        }
    }
}
