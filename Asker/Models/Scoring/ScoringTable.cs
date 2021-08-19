﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskerTracker.Models.Scoring
{
    public class ScoringTable
    {
        public static SortedDictionary<int, int> MdlScoringTable = new SortedDictionary<int, int>()
        {
            { 80, 0 },
            { 90, 10 },
            { 100, 20 },
            { 110, 30 },
            { 120, 40 },
            { 130, 50 },
            { 140, 60 },
            { 150, 62 },
            { 160, 63 },
            { 170, 64 },
            { 180, 65 },
            { 190, 68 },
            { 200, 70 },
            { 210, 72 },
            { 220, 74 },
            { 230, 76 },
            { 240, 78 },
            { 250, 80 },
            { 260, 82 },
            { 270, 84 },
            { 280, 86 },
            { 290, 88 },
            { 300, 90 },
            { 310, 92 },
            { 320, 94 },
            { 330, 97 },
            { 340, 100 }
        };

        public static SortedDictionary<double, int> SptScoringTable = new SortedDictionary<double, int>()
        {
            { 3.3, 0 },
            { 3.4, 5 },
            { 3.5, 10 },
            { 3.6, 15 },
            { 3.7, 20 },
            { 3.8, 25 },
            { 3.9, 30 },
            { 4.0, 35 },
            { 4.1, 40 },
            { 4.2, 45 },
            { 4.3, 50 },
            { 4.4, 55 },
            { 4.5, 60 },
            { 4.9, 61 },
            { 5.4, 62 },
            { 5.8, 63 },
            { 6.2, 64 },
            { 6.5, 65 },
            { 6.8, 66 },
            { 7.1, 67 },
            { 7.5, 68 },
            { 7.8, 69 },
            { 8.0, 70 },
            { 8.2, 71 },
            { 8.3, 72 },
            { 8.5, 73 },
            { 8.6, 74 },
            { 8.8, 75 },
            { 8.9, 76 },
            { 9.1, 77 },
            { 9.2, 78 },
            { 9.4, 79 },
            { 9.5, 80 },
            { 9.7, 81 },
            { 9.8, 82 },
            { 10.0, 83 },
            { 10.1, 84 },
            { 10.3, 85 },
            { 10.4, 86 },
            { 10.6, 87 },
            { 10.7, 88 },
            { 10.9, 89 },
            { 11.0, 90 },
            { 11.2, 91 },
            { 11.3, 92 },
            { 11.5, 93 },
            { 11.6, 94 },
            { 11.8, 95 },
            { 11.9, 96 },
            { 12.1, 97 },
            { 12.2, 98 },
            { 12.4, 99 },
            { 12.5, 100 }
        };

        public static SortedDictionary<int, int> HrpScoringTable = new SortedDictionary<int, int>()
        {
            { 1, 15 },
            { 2, 20 },
            { 3, 25 },
            { 4, 30 },
            { 5, 35 },
            { 6, 40 },
            { 7, 45 },
            { 8, 50 },
            { 9, 55 },
            { 10, 60 },
            { 12, 61 },
            { 14, 62 },
            { 16, 63 },
            { 18, 64 },
            { 20, 65 },
            { 22, 66 },
            { 24, 67 },
            { 26, 68 },
            { 28, 69 },
            { 30, 70 },
            { 31, 71 },
            { 32, 72 },
            { 33, 73 },
            { 34, 74 },
            { 35, 75 },
            { 36, 76 },
            { 37, 77 },
            { 38, 78 },
            { 39, 79 },
            { 40, 80 },
            { 41, 81 },
            { 42, 82 },
            { 43, 83 },
            { 44, 84 },
            { 45, 85 },
            { 46, 86 },
            { 47, 87 },
            { 48, 88 },
            { 49, 89 },
            { 50, 90 },
            { 51, 91 },
            { 52, 92 },
            { 53, 93 },
            { 54, 94 },
            { 55, 95 },
            { 56, 96 },
            { 57, 97 },
            { 58, 98 },
            { 59, 99 },
            { 60, 100 }
        };
        public static SortedDictionary<TimeSpan, int> SdcScoringTable = new SortedDictionary<TimeSpan, int>()
        {
            { new TimeSpan(0, 1, 33), 100 },
            { new TimeSpan(0, 1, 36), 99 },
            { new TimeSpan(0, 1, 39), 98 },
            { new TimeSpan(0, 1, 41), 97 },
            { new TimeSpan(0, 1, 43), 96 },
            { new TimeSpan(0, 1, 45), 95 },
            { new TimeSpan(0, 1, 46), 94 },
            { new TimeSpan(0, 1, 47), 93 },
            { new TimeSpan(0, 1, 48), 92 },
            { new TimeSpan(0, 1, 49), 91 },
            { new TimeSpan(0, 1, 50), 90 },
            { new TimeSpan(0, 1, 51), 89 },
            { new TimeSpan(0, 1, 52), 88 },
            { new TimeSpan(0, 1, 53), 87 },
            { new TimeSpan(0, 1, 54), 86 },
            { new TimeSpan(0, 1, 55), 85 },
            { new TimeSpan(0, 1, 56), 84 },
            { new TimeSpan(0, 1, 57), 83 },
            { new TimeSpan(0, 1, 58), 82 },
            { new TimeSpan(0, 1, 59), 81 },
            { new TimeSpan(0, 2, 00), 80 },
            { new TimeSpan(0, 2, 1), 79 },
            { new TimeSpan(0, 2, 2), 78 },
            { new TimeSpan(0, 2, 3), 77 },
            { new TimeSpan(0, 2, 4), 76 },
            { new TimeSpan(0, 2, 5), 75 },
            { new TimeSpan(0, 2, 6), 74 },
            { new TimeSpan(0, 2, 7), 73 },
            { new TimeSpan(0, 2, 8), 72 },
            { new TimeSpan(0, 2, 9), 71 },
            { new TimeSpan(0, 2, 10), 70 },
            { new TimeSpan(0, 2, 14), 69 },
            { new TimeSpan(0, 2, 18), 68 },
            { new TimeSpan(0, 2, 22), 67 },
            { new TimeSpan(0, 2, 26), 66 },
            { new TimeSpan(0, 2, 30), 65 },
            { new TimeSpan(0, 2, 35), 64 },
            { new TimeSpan(0, 2, 40), 63 },
            { new TimeSpan(0, 2, 45), 62 },
            { new TimeSpan(0, 2, 50), 61 },
            { new TimeSpan(0, 3, 0), 60 },
            { new TimeSpan(0, 3, 1), 59 },
            { new TimeSpan(0, 3, 2), 58 },
            { new TimeSpan(0, 3, 3), 57 },
            { new TimeSpan(0, 3, 4), 56 },
            { new TimeSpan(0, 3, 5), 55 },
            { new TimeSpan(0, 3, 6), 54 },
            { new TimeSpan(0, 3, 7), 53 },
            { new TimeSpan(0, 3, 8), 52 },
            { new TimeSpan(0, 3, 9), 51 },
            { new TimeSpan(0, 3, 10), 50 },
            { new TimeSpan(0, 3, 11), 48 },
            { new TimeSpan(0, 3, 12), 46 },
            { new TimeSpan(0, 3, 13), 44 },
            { new TimeSpan(0, 3, 14), 42 },
            { new TimeSpan(0, 3, 15), 40 },
            { new TimeSpan(0, 3, 16), 38 },
            { new TimeSpan(0, 3, 17), 36 },
            { new TimeSpan(0, 3, 18), 34 },
            { new TimeSpan(0, 3, 19), 32 },
            { new TimeSpan(0, 3, 20), 30 },
            { new TimeSpan(0, 3, 21), 28 },
            { new TimeSpan(0, 3, 22), 26 },
            { new TimeSpan(0, 3, 23), 24 },
            { new TimeSpan(0, 3, 24), 22 },
            { new TimeSpan(0, 3, 25), 20 },
            { new TimeSpan(0, 3, 26), 18 },
            { new TimeSpan(0, 3, 27), 16 },
            { new TimeSpan(0, 3, 28), 14 },
            { new TimeSpan(0, 3, 29), 12 },
            { new TimeSpan(0, 3, 30), 10 },
            { new TimeSpan(0, 3, 31), 8 },
            { new TimeSpan(0, 3, 32), 6 },
            { new TimeSpan(0, 3, 33), 4 },
            { new TimeSpan(0, 3, 34), 2 },
            { new TimeSpan(0, 3, 35), 0 }
        };

        public static SortedDictionary<int, int> LtkScoringTable = new SortedDictionary<int, int>()
        {
            { 0, 0 },
            { 1, 60 },
            { 2, 62 },
            { 3, 65 },
            { 4, 68 },
            { 5, 70 },
            { 6, 72 },
            { 7, 74 },
            { 8, 76 },
            { 9, 78 },
            { 10, 80 },
            { 11, 82 },
            { 12, 84 },
            { 13, 86 },
            { 14, 88 },
            { 15, 90 },
            { 16, 92 },
            { 17, 94 },
            { 18, 96 },
            { 19, 98 },
            { 20, 100 }
        };

        public static SortedDictionary<TimeSpan, int> TmrScoringTable = new SortedDictionary<TimeSpan, int>()
        {
            { new TimeSpan(0, 13, 30), 100 },
            { new TimeSpan(0, 13, 39), 99 },
            { new TimeSpan(0, 13, 48), 98 },
            { new TimeSpan(0, 13, 57), 97 },
            { new TimeSpan(0, 14, 06), 96 },
            { new TimeSpan(0, 14, 15), 95 },
            { new TimeSpan(0, 14, 24), 94 },
            { new TimeSpan(0, 14, 33), 93 },
            { new TimeSpan(0, 14, 42), 92 },
            { new TimeSpan(0, 14, 51), 91 },
            { new TimeSpan(0, 15, 0), 90 },
            { new TimeSpan(0, 15, 9), 89 },
            { new TimeSpan(0, 15, 18), 88 },
            { new TimeSpan(0, 15, 27), 87 },
            { new TimeSpan(0, 15, 36), 86 },
            { new TimeSpan(0, 15, 45), 85 },
            { new TimeSpan(0, 15, 54), 84 },
            { new TimeSpan(0, 16, 3), 83 },
            { new TimeSpan(0, 16, 12), 82 },
            { new TimeSpan(0, 16, 21), 81 },
            { new TimeSpan(0, 16, 30), 80 },
            { new TimeSpan(0, 16, 39), 79 },
            { new TimeSpan(0, 16, 48), 78 },
            { new TimeSpan(0, 16, 57), 77 },
            { new TimeSpan(0, 17, 6), 76 },
            { new TimeSpan(0, 17, 15), 75 },
            { new TimeSpan(0, 17, 24), 74 },
            { new TimeSpan(0, 17, 33), 73 },
            { new TimeSpan(0, 17, 42), 72 },
            { new TimeSpan(0, 17, 51), 71 },
            { new TimeSpan(0, 18, 0), 70 },
            { new TimeSpan(0, 18, 12), 69 },
            { new TimeSpan(0, 18, 24), 68 },
            { new TimeSpan(0, 18, 36), 67 },
            { new TimeSpan(0, 18, 48), 66 },
            { new TimeSpan(0, 19, 0), 65 },
            { new TimeSpan(0, 19, 24), 64 },
            { new TimeSpan(0, 19, 48), 63 },
            { new TimeSpan(0, 20, 12), 62 },
            { new TimeSpan(0, 20, 36), 61 },
            { new TimeSpan(0, 21, 0), 60 },
            { new TimeSpan(0, 21, 1), 59 },
            { new TimeSpan(0, 21, 3), 58 },
            { new TimeSpan(0, 21, 5), 57 },
            { new TimeSpan(0, 21, 7), 56 },
            { new TimeSpan(0, 21, 9), 55 },
            { new TimeSpan(0, 21, 10), 54 },
            { new TimeSpan(0, 21, 12), 53 },
            { new TimeSpan(0, 21, 14), 52 },
            { new TimeSpan(0, 21, 16), 51 },
            { new TimeSpan(0, 21, 18), 50 },
            { new TimeSpan(0, 21, 19), 49 },
            { new TimeSpan(0, 21, 21), 48 },
            { new TimeSpan(0, 21, 23), 47 },
            { new TimeSpan(0, 21, 25), 46 },
            { new TimeSpan(0, 21, 27), 45 },
            { new TimeSpan(0, 21, 28), 44 },
            { new TimeSpan(0, 21, 30), 43 },
            { new TimeSpan(0, 21, 32), 42 },
            { new TimeSpan(0, 21, 34), 41 },
            { new TimeSpan(0, 21, 36), 40 },
            { new TimeSpan(0, 21, 37), 39 },
            { new TimeSpan(0, 21, 39), 38 },
            { new TimeSpan(0, 21, 41), 37 },
            { new TimeSpan(0, 21, 43), 36 },
            { new TimeSpan(0, 21, 45), 35 },
            { new TimeSpan(0, 21, 46), 34 },
            { new TimeSpan(0, 21, 48), 33 },
            { new TimeSpan(0, 21, 50), 32 },
            { new TimeSpan(0, 21, 52), 31 },
            { new TimeSpan(0, 21, 54), 30 },
            { new TimeSpan(0, 21, 55), 29 },
            { new TimeSpan(0, 21, 57), 28 },
            { new TimeSpan(0, 21, 59), 27 },
            { new TimeSpan(0, 22, 01), 26 },
            { new TimeSpan(0, 22, 03), 25 },
            { new TimeSpan(0, 22, 04), 24 },
            { new TimeSpan(0, 22, 06), 23 },
            { new TimeSpan(0, 22, 08), 22 },
            { new TimeSpan(0, 22, 10), 21 },
            { new TimeSpan(0, 22, 12), 20 },
            { new TimeSpan(0, 22, 13), 19 },
            { new TimeSpan(0, 22, 15), 18 },
            { new TimeSpan(0, 22, 17), 17 },
            { new TimeSpan(0, 22, 19), 16 },
            { new TimeSpan(0, 22, 21), 15 },
            { new TimeSpan(0, 22, 22), 14 },
            { new TimeSpan(0, 22, 24), 13 },
            { new TimeSpan(0, 22, 26), 12 },
            { new TimeSpan(0, 22, 28), 11 },
            { new TimeSpan(0, 22, 30), 10 },
            { new TimeSpan(0, 22, 31), 9 },
            { new TimeSpan(0, 22, 33), 8 },
            { new TimeSpan(0, 22, 35), 7 },
            { new TimeSpan(0, 22, 37), 6 },
            { new TimeSpan(0, 22, 38), 5 },
            { new TimeSpan(0, 22, 40), 4 },
            { new TimeSpan(0, 22, 42), 3 },
            { new TimeSpan(0, 22, 44), 2 },
            { new TimeSpan(0, 22, 46), 1 },
            { new TimeSpan(0, 22, 48), 0 }
        };
    }
}
