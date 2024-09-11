import { StudentGrade } from "./studentGrade";

export interface Student {
  id: string;
  firstName: string;
  lastName: string;
  gender: string;
  birthDay: string;
  grades: StudentGrade[];
}
