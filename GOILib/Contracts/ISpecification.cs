namespace GOILib.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This interface defines the contract of a specification for a given type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Should return true if the object obj meets the specification represented by the contract
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsSatisfiedBy(T obj);
    }
}
