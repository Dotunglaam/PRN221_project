using InstructorSchedule.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasctructrue.DAL
{
    public interface IUnitOfWork
    {
        IBaseRepository<Event, Event> EventRepository { get; }
        IBaseRepository<Role, Role> RoleRepository { get; }
        IBaseRepository<Subject, Subject> SubjectRepository { get; }
        IBaseRepository<User, User> UserRepository { get; }
        Task<int> SaveChangeAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext = new AppDbContext();
        IBaseRepository<Event, Event> eventRepository;
        IBaseRepository<Role, Role> roleRepository;
        IBaseRepository<Subject, Subject> subjectRepository;
        IBaseRepository<User, User> userRepository;

        public IBaseRepository<Event, Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new BaseRepository<Event, Event>(_appDbContext);
                }
                return eventRepository;
            }
        }

        public IBaseRepository<Role, Role> RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new BaseRepository<Role, Role>(_appDbContext);
                }
                return roleRepository;
            }
        }

        public IBaseRepository<Subject, Subject> SubjectRepository
        {
            get
            {

                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new BaseRepository<Subject, Subject>(_appDbContext);
                }
                return subjectRepository;
            }
        }

        public IBaseRepository<User, User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new BaseRepository<User, User>(_appDbContext);
                }
                return userRepository;
            }
        }



        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
