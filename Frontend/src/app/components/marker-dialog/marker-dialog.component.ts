import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PlaceService } from 'src/app/services/place.service';

@Component({
  selector: 'app-marker-dialog',
  templateUrl: './marker-dialog.component.html',
  styleUrls: ['./marker-dialog.component.css']
})
export class MarkerDialogComponent implements OnInit{
  place: any;
  description: string;

  constructor (
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<MarkerDialogComponent>,
    private placeService: PlaceService,
    private http: HttpClient){}

  ngOnInit(): void {
    this.getPlaceByXid(this.data.xid);
  }

  onClose(){
    this.dialogRef.close();
  }

  getPlaceByXid(id: string){
    this.placeService.getPlaceInfoById(id).subscribe(p => {
      console.log(p);
      this.place = p;
      console.log(this.place);
      console.log(this.place.Image.split(':')[2]);
      this.http.get('https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=Tour_Eiffel')
        .subscribe(r => {
          console.log(r);
        })
    })
  }
}
