import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { user } from '../../../Models/User';
import { UsersService } from '../../../Services/Auth/Users/users.service';

@Component({
  selector: 'app-show-users',
  standalone: true,
  imports: [MatIconModule,MatButtonModule,RouterLinkActive, 
    RouterLink,
    RouterOutlet,MatIconModule, MatButtonModule, FormsModule],
  templateUrl: './show-users.component.html',
  styleUrl: './show-users.component.css'
})
export class ShowUsersComponent {
  courseId: string = '';
  User!: user  // משתנה course שיכול להיות null או מסוג Course
  Users: user[] = [];

  constructor( private dialog: MatDialog,private activatedRoute: ActivatedRoute, private usersService: UsersService ,private router: Router,
  ) {}

  ngOnInit(): void {
    
        this.loadUsers();
        // קריאה לפונקציה אחרי שקיבלנו את ה-ID
      }
    
loadUsers(): void {
   this.usersService.getUsers().subscribe({
      next: (data) => {
        console.log("Data from server:", data); // הוסף את זה

        this.Users = data;
        
        
        
      },
      error: (error) => {
        console.error('Error fetching courses:', error);
        
      }
    });
  }
  // deleteLesson(lesson:Lesson )
  // {
  //    this.lessonservies.deleteLesson(lesson.courseId,lesson.id).subscribe({
  //       next: () => {
  //         this.lessons = this.lessons.filter(l => l.id !== lesson.id);
  //       },
  //       error: () => {
  //         // this.openErrorDialog('שגיאה במחיקת הקורס');
  //       }
  //     });
  //   }
  // editLesson(Lesson:Lesson ): void {
  //     const lesson: Lesson = this.lessons.find(c => c.id === Lesson.id)||{title:
  //       '',
  //       content: '',
  //       courseId: '',
  //       id: ''
  //     } 
  //     if (!lesson) return;
    
  //     const dialogRef = this.dialog.open(EditLessonComponent, {
  //       width: '400px',
  //       data: {
  //         title: lesson.title,
  //         content: lesson.content,
  //         courseId: lesson.courseId ,
  //         id:lesson.id
  //       }
  //     });
    
  //     dialogRef.afterClosed().subscribe(result => {
  //       if (result) {
    
  //         result.courseId = lesson.courseId; 
  //         result.id = lesson.id; 

    
  //         this.lessonservies.updateLesson(Lesson.courseId,Lesson.id ,result).subscribe({
  //           next: () => this.loadLesson(),
  //           // error: () => this.openErrorDialog('שגיאה בעדכון הקורס')
  //         });
  //       }
  //     });
  //   }



  }





