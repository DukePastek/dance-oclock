import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-bachata',
  imports: [MatCardModule],
  templateUrl: './bachata.html',
  styleUrl: './bachata.scss'
})
export class Bachata {
  protected readonly styles = [
    {
      name: 'Bachata Moderne',
      description:
        "Une évolution de la bachata traditionnelle intégrant des figures inspirées d'autres danses de couple (salsa, kizomba, danses de salon). Plus technique, elle multiplie les tours, portés et jeux de jambes tout en gardant le tempo à 4 temps caractéristique."
    },
    {
      name: 'Bachata Traditionnelle',
      description:
        "Le style d'origine, tel qu'il se danse en République Dominicaine : pas simples, déhanché naturel et proximité avec le/la partenaire. L'accent est mis sur la musicalité et l'ambiance conviviale plutôt que sur la performance technique."
    },
    {
      name: 'Bachata Sensual',
      description:
        "Apparu dans les années 2000, ce style met l'accent sur la fluidité du corps, les ondulations et une connexion rapprochée entre les danseurs. Il emprunte des mouvements au contemporain et au tango pour une gestuelle plus expressive."
    },
    {
      name: 'Nouveaux styles',
      description:
        "La bachata continue d'évoluer avec des courants comme l'Urban Kiz ou des fusions expérimentales, mélangeant influences urbaines, contemporaines et électroniques tout en conservant l'âme de la danse d'origine."
    }
  ];
}
