﻿// <copyright file="StreamSpecimenBuilder.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders
{
    using System.IO;
    using AutoFixture.Kernel;
    using BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders.Base;

    /// <summary>
    /// SpecimenBuilder that ignores the virtual members
    /// </summary>
    public class StreamSpecimenBuilder : SpecimenBuilderBase, ISpecimenBuilder
    {
        /// <summary>
        /// Creates a new <see cref="Stream"/> specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="T:AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <remarks>
        ///   <para>
        /// The <paramref name="request" /> can be any object, but will often be a
        ///   <see cref="T:System.Type" /> or other <see cref="T:System.Reflection.MemberInfo" /> instances.
        ///   </para>
        ///   <para>
        /// Note to implementers: Implementations are expected to return a
        ///   <see cref="T:AutoFixture.Kernel.NoSpecimen" /> instance if they can't satisfy the request.
        ///   </para>
        /// </remarks>
        public override object Create(object request, ISpecimenContext context)
        {
            if (!this.IsRequestForType(request, typeof(Stream)))
            {
                return new NoSpecimen();
            }

            var data = (byte[])context.Resolve(typeof(byte[]));
            var stream = new MemoryStream(data);
            return stream;
        }
    }
}
