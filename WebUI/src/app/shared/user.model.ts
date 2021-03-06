export class UserModel {
    UserId: number;
    UserName: string;
    FirstName: string;
    LastName: string;
    DateOfBirth: string;
    Gender: string;
    MailId: string;
    CreatedBy: number;
    CreatedTime: string;
    UpdatedBy: number;
    UpdatedTime: string;
}

export class UserLoginModel {
    UserName: string;
    Password: string;
}

export class UserLoginReponseModel{
    roleID:number;
    token:string;
    userName:string;
}