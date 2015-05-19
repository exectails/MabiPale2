using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiDungeon
{
	public class MTRandom
	{
		private const int N = 624;
		private const int M = 397;
		private const uint MATRIX_A = 0x9908B0DF;

		private uint[] _mt;
		private int _mti;

		public MTRandom(int seed = 5498)
			: this((uint)seed)
		{
		}

		public MTRandom(uint seed = 5498)
		{
			_mti = N;
			_mt = new uint[N];

			uint x = seed;
			_mt[0] = x;
			for (int i = 1; i < N; i++)
			{
				x = 1812433253U * (x ^ (x >> 30)) + (uint)i;
				_mt[i] = x;
			}
		}

		/// <summary>
		/// Generates random number between 0 and uint max.
		/// </summary>
		/// <returns></returns>
		public uint GetUInt32()
		{
			if (_mti >= N)
			{
				for (int i = 0; i < N - M; i++)
				{
					uint x = _mt[i];
					x ^= (x ^ _mt[i + 1]) & 0x7FFFFFFF;
					_mt[i] = _mt[i + M] ^ (x >> 1) ^ ((x & 1) == 0 ? 0 : MATRIX_A);
				}
				for (int i = N - M; i < N - 1; i++)
				{
					uint x = _mt[i];
					x ^= (x ^ _mt[i + 1]) & 0x7FFFFFFF;
					_mt[i] = _mt[i + M - N] ^ (x >> 1) ^ ((x & 1) == 0 ? 0 : MATRIX_A);
				}
				{
					uint x = _mt[N - 1];
					x ^= (x ^ _mt[0]) & 0x7FFFFFFF;
					_mt[N - 1] = _mt[M - 1] ^ (x >> 1) ^ ((x & 1) == 0 ? 0 : MATRIX_A);
				}
				_mti = 0;
			}

			uint y = _mt[_mti++];
			y ^= (y >> 11);
			y ^= (y << 7) & 0x9D2C5680U;
			y ^= (y << 15) & 0xEFC60000U;
			y ^= (y >> 18);
			return y;
		}

		public int GetInt32()
		{
			return (int)GetUInt32();
		}

		/// <summary>
		/// Generates random number between 0 and max - 1.
		/// Example: max = 10 returns a number from 0 to 9.
		/// </summary>
		/// <param name="max"></param>
		/// <returns></returns>
		public uint GetUInt32(uint max)
		{
			return this.GetUInt32(0, max - 1);
		}

		/// <summary>
		/// Generates random number between min and max.
		/// Example: min = 1 and max = 10 returns a number from 1 to 10.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public uint GetUInt32(uint min, uint max)
		{
			return (uint)(this.GetDouble() * (max + 1 - min) + min);
		}

		/// <summary>
		/// Generates a random number between 0.0 and 1.0 (not including 1.0).
		/// </summary>
		/// <returns></returns>
		public double GetDouble()
		{
			return ((double)this.GetUInt32() / 0xFFFFFFFFU);
		}
	}
}
