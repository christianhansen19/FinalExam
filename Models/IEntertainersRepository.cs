using System;
namespace FinalExam.Models

{
	public interface IEntertainersRepository
	{
		IQueryable<Entertainer> Entertainers { get; }
	}
}

