export interface Ticket {
  id: string;
  title: string;
  created: Date;
  closed: Date;
  description: string;
  lastModified: Date;
  userId: string;
  appUserName: string;
}
