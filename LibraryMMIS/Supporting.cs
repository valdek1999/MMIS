﻿using System;
using Microsoft.VisualBasic.CompilerServices;

namespace LibraryMMIS
{
    public static class Supporting
    {
        static long Min(long x, long y) 
        { 
            return x < y ? x : y; 
        }

        static long Max(long x, long y)
        { 
            return x > y ? x : y;
        }
        
        public static bool Simple(long n) //проверка на простоту числа
        { 
            
            for (long i = 2; i <= Math.Sqrt(n); i++) 
                if (n % i == 0) 
                    return false; 
            return true; 
        }

        
        static long GetNOD(long a, long b) //Поиск NOD
        {
            if (a == 0) 
            { 
                return b; 
            }
            else 
            { 
                var min = Min(a, b); 
                var max = Max(a, b); 
                //вызываем метод с новыми аргументами
                return GetNOD(max % min, min); 
            } 
        }

        public static bool MutuallySimple(long val1, long val2) //проверка на взаимную простоту чисел.
        {
            return GetNOD(val1, val2) == 1;
        }


        public static long GetMutuallySimple(long val1) //получить первое взаимное простое число с числом поданным на вход.
        {
            long i = 2;

            while (i < val1)
            {
                if (MutuallySimple(val1, i))
                    return i;
                i++;
            }

            return val1;
        }

        public static long ResolveModuleEquation(long st, long en, long y, long a, long b) //уравнение типа yx mod a = b 
        {
            if (b >= a)
                throw new Exception("b should be less a");
            for (long i = st; i < en; i++)
            {
                if (y * i % a == b)
                    return i;
            }

            throw new Exception("Equation haven`t resolve");
            return 0;
        }

        public static long ResolveDeofantovoEquation(ref long x, ref long y, long a, long b,long c)
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = -100; j <= 100; j++)
                {
                    if (i * a + j * b == c)
                    {
                        x = i;
                        y = j;
                        return 0;
                    }
                }
            }
            
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    if (i * a + j * b == c)
                    {
                        x = i;
                        y = j;
                        return 0;
                    }
                }
            }
            return 0;
        }
        
        public static long bin_pow(long b, long p, long MOD) {
            if (p == 1) {
                return b;    //Выход из рекурсии.
            }

            if (p % 2 == 0) {
                long t = bin_pow(b,p / 2, MOD);
                return t * t % MOD;
            } else {
                return bin_pow(b,p - 1, MOD) * b % MOD;
            }
        }
        
        public static long inverse_element(long x,long MOD) {
            return bin_pow(x, MOD - 2,MOD);
        }

        //(a / b) mod m
        public static long divide(long a,long b, long MOD) {
            return a * inverse_element(b,MOD) % MOD;
        }
        
        public static long divide_pow(long a,long pow, long MOD)///деление выражений 1/a+
        {
            long t = 1;
            for (int i = 0; i < pow; i++)
            {
                t *= inverse_element(a, MOD);
            }
            return t % MOD;
        }
        
        
    }
}