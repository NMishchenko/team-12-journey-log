import { Component, OnInit, ChangeDetectorRef} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import * as mapboxgl from 'mapbox-gl';
import { MarkerDialogComponent } from '../marker-dialog/marker-dialog.component';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { PlaceService } from 'src/app/services/place.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  map: mapboxgl.Map;
  style = 'mapbox://styles/mapbox/streets-v11';
  screenBox: any;
  coordinatesList: any = [];
  currentMarkers: any = [];

  constructor(
    private dialog: MatDialog,
    private placeService: PlaceService) {}

  ngOnInit() {
    mapboxgl as typeof mapboxgl;
    this.map = new mapboxgl.Map({
      accessToken:
        'pk.eyJ1Ijoib2F0YW1hbmNodWsiLCJhIjoiY2xnN3k1ODU2MHM3NjNnbzkzMnJ5amFrOSJ9.fUOEKrtONXbZfxQsn4YDlw',
      container: 'map',
      style: this.style,
      zoom: 3,
      center: [-74.5, 40]
    });

    this.map.addControl(new mapboxgl.NavigationControl());

    this.map.on('mouseup', (e) => {
      this.screenBox = this.map.getBounds();

      let max_lon = this.screenBox._ne.lng;
      let max_lat = this.screenBox._ne.lat;
      let min_lon = this.screenBox._sw.lng;
      let min_lat = this.screenBox._sw.lat;

      const bbox: any = {};

      bbox.max_lon = max_lon;
      bbox.max_lat = max_lat;
      bbox.min_lon = min_lon;
      bbox.min_lat = min_lat;

      this.placeService.getPlacesByBbox(bbox).subscribe(r => {
        this.coordinatesList = r;
        console.log(this.coordinatesList)

        this.currentMarkers.forEach((m: any) => m.remove());

        for (let i = 0; i < this.coordinatesList.length; i++){
          const customMarker = document.createElement('div');

          customMarker.style.backgroundImage = 'url(https://www.pngall.com/wp-content/uploads/2017/05/Map-Marker-PNG-File.png)';
          customMarker.style.backgroundSize = 'cover';
          customMarker.style.backgroundPosition = 'center';
          customMarker.style.width = '40px';
          customMarker.style.height = '40px';
          customMarker.style.borderRadius = '50%';
          // customMarker.style.border = '4px solid white';
          customMarker.setAttribute('id', this.coordinatesList[i].Xid);

          customMarker.addEventListener('click', () => {
            let xid = customMarker.getAttribute('id');

            const dialogOptions = {
              width: '650px',
              height: '600px',
              bgcolor: 'white',
              data: {
                xid: xid
              }
            }

            this.dialog.open(MarkerDialogComponent, dialogOptions);
          })

          this.currentMarkers.push(new mapboxgl.Marker(customMarker)
            .setLngLat([this.coordinatesList[i].Lon, this.coordinatesList[i].Lat])
            .addTo(this.map));
        }
      })
    })
  }
}
