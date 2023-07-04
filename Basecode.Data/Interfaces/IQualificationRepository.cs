using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Interfaces
{
    /// <summary>
    /// Interface for the Qualification repository.
    /// </summary>
    public interface IQualificationRepository
    {
        /// <summary>
        /// Gets all qualifications.
        /// </summary>
        /// <returns>An IQueryable of Qualification objects.</returns>
        IQueryable<Qualification> GetAll();

        /// <summary>
        /// Adds a new qualification.
        /// </summary>
        /// <param name="qualification">The qualification to add.</param>
        void AddQualification(Qualification qualification);

        /// <summary>
        /// Gets a qualification by its ID.
        /// </summary>
        /// <param name="id">The ID of the qualification to get.</param>
        /// <returns>The Qualification object with the specified ID.</returns>
        Qualification GetQualificationById(int id);

        /// <summary>
        /// Updates an existing qualification.
        /// </summary>
        /// <param name="qualification">The qualification to update.</param>
        void UpdateQualification(Qualification qualification);

        /// <summary>
        /// Deletes a qualification.
        /// </summary>
        /// <param name="qualification">The qualification to delete.</param>
        void DeleteQualification(Qualification qualification);
    }
}
