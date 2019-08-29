export class User {
  userId: number;
  fullname: string;
  username: string;
  password: string;
  contact: string;
  role: string;
  constructor() {
      this.userId = 0;
      this.fullname = '';
      this.username = '';
      this.role = '';
      this.password = '';
      this.contact ='';
  }
}