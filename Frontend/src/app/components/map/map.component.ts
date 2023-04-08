import { Component, OnInit, ChangeDetectorRef} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import * as mapboxgl from 'mapbox-gl';
import { MarkerDialogComponent } from '../marker-dialog/marker-dialog.component';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  map: mapboxgl.Map;
  style = 'mapbox://styles/mapbox/streets-v11';
  lat = 26.3398;
  lng = -81.7787;

  constructor(private dialog: MatDialog) {}

  ngOnInit() {
    mapboxgl as typeof mapboxgl;
    this.map = new mapboxgl.Map({
      accessToken:
        'pk.eyJ1Ijoib2F0YW1hbmNodWsiLCJhIjoiY2xnN3k1ODU2MHM3NjNnbzkzMnJ5amFrOSJ9.fUOEKrtONXbZfxQsn4YDlw',
      container: 'map',
      style: this.style,
      zoom: 2,
      center: [this.lng, this.lat],
    });

    this.map.addControl(new mapboxgl.NavigationControl());

    for (let i = 0; i < 2; i++){
      const customMarker = document.createElement('div');

      customMarker.style.backgroundImage = 'url(https://gorod.dp.ua/pic/placeimages/07/488/logo.jpg)';
      customMarker.style.backgroundSize = 'cover';
      customMarker.style.backgroundPosition = 'center';
      customMarker.style.width = '40px';
      customMarker.style.height = '40px';
      customMarker.style.borderRadius = '50%';
      customMarker.style.border = '4px solid white';
      customMarker.setAttribute('id', i.toString());

      customMarker.addEventListener('click', () => {
        let id = customMarker.getAttribute('id');

        const dialogOptions = {
          width: '650px',
          height: '600px',
          bgcolor: '#FFFAFA',
          data: {
            id: id
          }
        }
        this.dialog.open(MarkerDialogComponent, dialogOptions);
      })

      new mapboxgl.Marker(customMarker)
        .setLngLat([30.5, 50.5 + (i) * 10])
        .addTo(this.map);
    }
  }
}
