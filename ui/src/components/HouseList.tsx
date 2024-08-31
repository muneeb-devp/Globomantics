import { Link, useNavigate } from 'react-router-dom'
import { useFetchHouses } from '../hooks/HouseHooks'
import { House } from '../types/house'
import ApiStatus from './ApiStatus'

type Props = {}

const HouseList = (props: Props) => {
  const nav = useNavigate()
  const { data, error, status, isSuccess } = useFetchHouses()

  if (!isSuccess) return <ApiStatus status={status} />

  return (
    <div>
      <div className="row mb-2">
        <h2 className="themeFontColor text-center">
          Houses currently on the market
        </h2>
      </div>
      <table className="table table-hover border">
        <thead className="table-dark">
          <tr>
            <th>Address</th>
            <th>Country</th>
            <th>Asking Price</th>
          </tr>
        </thead>
        <tbody>
          {data &&
            data.map((h: House) => (
              <tr key={h.id} onClick={() => nav(`/house/${h.id}`)}>
                <td>{h.address}</td>
                <td>{h.country}</td>
                <td>${h.price.toLocaleString('en-us')}</td>
              </tr>
            ))}
        </tbody>
      </table>
      <Link to={'/house/add'}>
        <button className="btn btn-outline-primary w-25">Add</button>
      </Link>
    </div>
  )
}

export default HouseList
