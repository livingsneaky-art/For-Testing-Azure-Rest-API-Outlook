using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using System.Linq;

namespace Basecode.Data.Repositories
{
    /// <summary>
    /// A repository for managing job openings.
    /// </summary>
    public class JobOpeningRepository : BaseRepository, IJobOpeningRepository
    {
        private readonly BasecodeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOpeningRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="context">The database context.</param>
        public JobOpeningRepository(IUnitOfWork unitOfWork, BasecodeContext context) : base(unitOfWork)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all job openings.
        /// </summary>
        /// <returns>A queryable collection of job openings.</returns>
        public IQueryable<JobOpening> GetAll()
        {
            return this.GetDbSet<JobOpening>();
        }

        /// <summary>
        /// Adds a new job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to add.</param>
        public void AddJobOpening(JobOpening jobOpening)
        {
            _context.JobOpening.Add(jobOpening);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a job opening by its ID.
        /// </summary>
        /// <param name="id">The ID of the job opening to get.</param>
        /// <returns>The job opening with the specified ID, or null if no such job opening exists.</returns>
        public JobOpening GetJobOpeningById(int id)
        {
            return _context.JobOpening.Find(id);
        }

        /// <summary>
        /// Updates an existing job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to update.</param>
        public void UpdateJobOpening(JobOpening jobOpening)
        {
            _context.JobOpening.Update(jobOpening);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to delete.</param>
        public void DeleteJobOpening(JobOpening jobOpening)
        {
            _context.JobOpening.Remove(jobOpening);
            _context.SaveChanges();
        }
    }
}
