import React from 'react';
import './Button.css';
import {Link} from 'react-router-dom'

const STYLES = ['btn--primary', 'btn--outline']

const SIZES = ['btn--medium', 'btn--large'];

export const Button = ({
    children,
    type,
    onClick,
    buttonStyle,
    buttonSize}) =>{
const checkButtonstyle = STYLES.includes(buttonStyle)
? buttonStyle
:STYLES[0];

const chcekButtonSize = SIZES.includes(buttonSize) ? buttonSize : SIZES[0]
return(
    <Link to='/logowanie' className='btn-mobile'>
     <button
     className={`btn ${checkButtonstyle} ${chcekButtonSize}`}
     onClick={onClick}
     type={type}
     >
        {children}
     </button>

    </Link>
)

};