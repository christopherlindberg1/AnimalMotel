﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    /// <summary>
    ///   Interface for implementation of classes that has a generic list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListManager<T>
    {
        /// <summary>
        ///   Property for getting the amomunt of objects stored in the list.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///   Method for adding an object to the list.
        /// </summary>
        /// <param name="aType">Object to add to list.</param>
        /// <returns>bool showing if object got added.</returns>
        bool Add(T aType);

        /// <summary>
        ///   Method for changing an object in the list.
        /// </summary>
        /// <param name="aType">Object to change.</param>
        /// <param name="index">Index of the object.</param>
        /// <returns>bool showing if object got changed.</returns>
        bool ChangeAt(T aType, int index);

        /// <summary>
        ///   Method for checking if a given index is within the range for the list.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>bool showing if index is within the list's range.</returns>
        bool CheckIndex(int index);

        /// <summary>
        ///   Method for deleting all objects int the list.
        /// </summary>
        void DeleteAll();

        /// <summary>
        ///   Method for deleting an object at a given index.
        /// </summary>
        /// <param name="index">Index of object.</param>
        /// <returns>bool showing if an object got deleted or not.</returns>
        bool DeleteAt(int index);

        /// <summary>
        ///   Method for getting an object at a given index.
        /// </summary>
        /// <param name="index">Index of the object.</param>
        /// <returns>object of the type that is stored in the list.</returns>
        T GetAt(int index);

        /// <summary>
        ///   Method for getting an array with string representations
        ///   of all objects stored in the list.
        /// </summary>
        /// <returns>array with string representations of all objects.</returns>
        string[] ToStringArray();

        /// <summary>
        ///   Method for getting a list with string representations
        ///   of all objects stored in the list.
        /// </summary>
        /// <returns>list with string representations of all objects.</returns>
        List<string> ToStringList();
    }
}