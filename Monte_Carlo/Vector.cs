using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    /// <summary>
    /// Vector - хранит три пространственные координаты (x, y, z), т.е. это точка в пространстве.
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public double x;

        /// <summary>
        /// Координата Y
        /// </summary>
        public double y;

        /// <summary>
        /// Координата Z
        /// </summary>
        public double z;

        /// <summary>
        /// Вектор состоящий из нулей.
        /// </summary>
        public static Vector Zero
        {
            get { return new Vector(0, 0, 0); }
        }

        /// <summary>
        /// Вектор состоящий из единиц.
        /// </summary>
        public static Vector One
        {
            get { return new Vector(1, 1, 1); }
        }

        /// <summary>
        /// Создание вектора.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="z">Координата Z.</param>
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Длина вектора, начальная точка - текущие координаты;
        /// для вычисления расстояния между атомами в структуре использовать <see cref="Vector.MagnitudePeriod(Vector, Vector, double)"/>.
        /// </summary>
        /// <param name="vector">Конечная точка.</param>
        /// <returns></returns>
        public double Magnitude(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.x - x, 2) + Math.Pow(vector.y - y, 2) + Math.Pow(vector.z - z, 2));
        }

        /// <summary>
        /// Длина вектора, начальная точка - текущие координаты, конечная точка нуль;
        /// для вычисления расстояния между атомами в структуре использовать <see cref="Vector.MagnitudePeriod(Vector, Vector, double)"/>.
        /// </summary>
        /// <returns></returns>
        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Длина вектора;
        /// для вычисления расстояния между атомами в структуре использовать <see cref="Vector.MagnitudePeriod(Vector, Vector, double)"/>.
        /// </summary>
        /// <param name="vector1">Начальная точка.</param>
        /// <param name="vector2">Конечная точка.</param>
        /// <returns></returns>
        public static double Magnitude(Vector vector1, Vector vector2)
        {
            return Math.Sqrt(Math.Pow(vector2.x - vector1.x, 2) + Math.Pow(vector2.y - vector1.y, 2) + Math.Pow(vector2.z - vector1.z, 2));
        }

        /// <summary>
        /// Вычисление расстояния между атомами с учётом кубических периодических граничных условий.
        /// </summary>
        /// <param name="vector1">Координата первого атома.</param>
        /// <param name="vector2">Координата второго атома.</param>
        /// <param name="L">Размер кубической расчётной ячейки.</param>
        /// <returns></returns>
        public static double MagnitudePeriod(Vector vector1, Vector vector2, double L)
        {
            double dx = vector1.x - vector2.x;
            if (Math.Abs(dx) > (L / 2.0)) dx -= Math.Sign(dx) * L;

            double dy = vector1.y - vector2.y;
            if (Math.Abs(dy) > (L / 2.0)) dy -= Math.Sign(dy) * L;

            double dz = vector1.z - vector2.z;
            if (Math.Abs(dz) > (L / 2.0)) dz -= Math.Sign(dz) * L;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// Возвращает значение наибольшей координаты.
        /// </summary>
        /// <returns></returns>
        public double MaxElement()
        {
            if (x >= y && x >= z) return x;
            else if (y >= x && y >= z) return y;
            else return z;
        }

        /// <summary>
        /// Возвращает значение наименьшей координаты.
        /// </summary>
        /// <returns></returns>
        public double MinElement()
        {
            if (x <= y && x <= z) return x;
            else if (y <= x && y <= z) return y;
            else return z;
        }

        /// <summary>
        /// Сложение координат.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }

        /// <summary>
        /// Вычитание из одной координаты другой координаты.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
        }

        /// <summary>
        /// Перемножение координат.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
        }

        /// <summary>
        /// Деление одной координаты на другую.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator /(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.x / vec2.x, vec1.y / vec2.y, vec1.z / vec2.z);
        }

        /// <summary>
        /// Умножение числа с плавающей запятой на точку справа.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec, double num)
        {
            return new Vector(vec.x * num, vec.y * num, vec.z * num);
        }

        /// <summary>
        /// Умножение целого числа на точку справа.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec, int num)
        {
            return new Vector(vec.x * num, vec.y * num, vec.z * num);
        }

        /// <summary>
        /// Умножение числа с плавающей запятой на точку слева.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(double num, Vector vec)
        {
            return new Vector(vec.x * num, vec.y * num, vec.z * num);
        }

        /// <summary>
        /// Умножение целого числа на точку слева.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(int num, Vector vec)
        {
            return new Vector(vec.x * num, vec.y * num, vec.z * num);
        }

        /// <summary>
        /// Деление точки на число с плавающей запятой.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Число-делитель.</param>
        /// <returns></returns>
        public static Vector operator /(Vector vec, double num)
        {
            return new Vector(vec.x / num, vec.y / num, vec.z / num);
        }

        /// <summary>
        /// Деление точки на целое число.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Число-делитель.</param>
        public static Vector operator /(Vector vec, int num)
        {
            return new Vector(vec.x / num, vec.y / num, vec.z / num);
        }
    }
}
