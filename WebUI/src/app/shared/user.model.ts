export class UserModel {
    UserId: number;
    UserName: string;
    FirstName: string;
    LastName: string;
    DateOfBirth: string;
    Gender: string;
    MailId: string;
    isActive: boolean;
    Role: number;
}

export class UserLoginModel {
    UserName: string;
    Password: string;
}

export class UserLoginReponseModel {
    roleID: number;
    token: string;
    userName: string;
}