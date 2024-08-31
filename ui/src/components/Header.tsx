import React from 'react'
import { Link } from 'react-router-dom'

type Props = { subtitle: string }

const Header = ({ subtitle }: Props) => {
  return (
    <header className="row mb-4">
      <div className="col-5">
        <Link to={'/'}>
          <img src="/GloboLogo.png" alt="Logo" className="logo" />
        </Link>
      </div>
      <p className="col-7 mt-5 subtitle">{subtitle}</p>
    </header>
  )
}

export default Header
