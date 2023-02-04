using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Services.UserAccount;

public interface IUserAccountService
{
	Task<UserAccountModel> Create(RegisterUserAccountModel model);
}
