import { Component, OnInit } from '@angular/core';
import { HttpRequest } from '@angular/common/http';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
 comments:any[]=[];
 formName;
 formDate;
 formBody;
  constructor() { }

  ngOnInit(): void {
    /*$('#container').append();*/
    if(!localStorage.commentData){
      localStorage.commentData=[];
  } else{
        this.comments=JSON.parse(localStorage.commentData);
  }
  
  /*for(var i=0;i<this.comments.length;i++){
     render(this.comments[i]);  
  }*/
} 
addComment() {
  
  let comment = {name: this.formName,
  date: this.formDate,
  body: this.formBody};
  
  this.comments.push(comment);
  localStorage.commentData = JSON.stringify(this.comments);
  } 
}
  


