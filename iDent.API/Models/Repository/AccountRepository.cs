using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;
using iDent.API.Services;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.ModelLibrary.Utility;
using Microsoft.EntityFrameworkCore;

namespace iDent.API.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly ICodeGeneratorService _codeGeneratorService;
        private readonly IEmailService _emailService;

        public AccountRepository(AppDbContext context, IConfiguration configuration, IPasswordService passwordService, IJwtService jwtService, ICodeGeneratorService codeGeneratorService, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _codeGeneratorService = codeGeneratorService;
            _emailService = emailService;
        }

        public Task<Result<Account>> AddAdminAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Account>> AddAsync(AccountRequest request)
        {
            try
            {
                if (!IsUniqueUser(request.Email!))
                    return new Result<Account>(false, "An account with that email already exists!");

                var account = new Account
                {
                    Email = request.Email,
                    Password = _passwordService.HashPassword(request.Password!),
                };

                await _context.Accounts!.AddAsync(account);
                await _context.SaveChangesAsync();

                var bank = new Bank
                {
                    AccountId = account.Id,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Name = request.Name
                };

                await _context.Banks!.AddAsync(bank);

                //SKIPPING FOR NOW, COZ PAKAIPA AND NDEZVEKUSHAYA!
                /**
                var code = await _codeGeneratorService.GenerateVerificationCode();

                await _context.GeneratedCodes!.AddAsync(new GeneratedCode
                {
                    Code = code,
                    UserEmail = account.Email,
                    DateCreated = DateTime.Now
                });

                await _emailService.SendEmailAsync(new EmailRequest
                {
                    To = account.Email,
                    Subject = _configuration["EmailService:ConfirmAccountSubject"],
                    Body = string.Format(_configuration["EmailService:ConfirmAccountBody"], account.FirstName, code)
                });
                **/

                await _context.SaveChangesAsync();

                return new Result<Account>(account, "Account created successfully!");
            }
            catch (Exception ex)
            {
                return new Result<Account>(false, ex.ToString());
            }
        }

        public Task<Result<bool>> DeleteAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAdminAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Pageable<Account>>> GetAllAdminPagedAsync(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GetResetPasswordCodeAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Account>> LoginAsync(LoginRequest login)
        {
            var account = await _context.Accounts!
               .Where(x => x.Email == login.Email)
               .FirstOrDefaultAsync();

            if (account == null || _passwordService.VerifyHash(login.Password!, account!.Password!) == false)
                return new Result<Account>(false, "Username or password is incorrect!");

            account.Token = await _jwtService.GenerateTokenAsync(account);
            account.Password = "***********";

            return new Result<Account>(account);
        }

        public Task<Result<string>> ResendOtpAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }

        private bool IsUniqueUser(string email) => _context.Accounts!.SingleOrDefault(x => x.Email == email) == null;

    }
}