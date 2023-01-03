import React from 'react';
import '../App.css';
import {Button} from './Button';
import './MainView.css';
import '../components/Stefan.png'





function MainView() {
  return (
    <div className='mainView-container'>
        <img src='./Stefan.png'/>
        <div className='welcome-message'>
        <p>
       
       Potrzebujesz pomocy{"\n"}
       w codziennych pracach ?{"\n"}
       A może szukasz dodatkowej pracy{"\n"}
       jako osoba sprzątajaca?
      
      </p>
        </div>
        
        <div className="main-btns">
            <Button className = 'btns' buttonstyle='btn-outline'
            buttonSize='btn--large'>+ dodaj ofertę</Button>


        </div>
      
    </div>
  )
}

export default MainView
