import React from 'react'

type Props = {
  status: 'success' | 'error' | 'pending'
}

const ApiStatus = ({ status }: Props) => {
  switch (status) {
    case 'error':
      return <div> Error communicating with the backend server!</div>
    case 'pending':
      return <div>Loading...</div>
    default:
      throw Error('Unknown API state')
  }
}

export default ApiStatus
