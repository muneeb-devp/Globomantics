import { Link, useNavigate, useParams } from 'react-router-dom'
import { useDeleteHouse, useFetchHouseDetail } from '../hooks/HouseHooks'
import { MdArrowBack } from 'react-icons/md'
import ApiStatus from './ApiStatus'
import Bids from './Bids'

type Props = {}

const HouseDetail = (props: Props) => {
  const { id } = useParams()
  const nav = useNavigate()

  if (!id) throw Error('House id not found!')

  const houseId: number = parseInt(id)
  const { data, status, isSuccess } = useFetchHouseDetail(houseId)
  const deleteHouseMutation = useDeleteHouse()

  if (!isSuccess) return <ApiStatus status={status} />
  if (!data) return <div> House not found!</div>

  return (
    <>
      <div className="row">
        <div className="col-6">
          <MdArrowBack size={24} className="back" onClick={() => nav(-1)} />
          <div className="row">
            <img
              className="img-fluid"
              src={data.photo ? data.photo : '/default_photo.png'}
              alt="House pic"
            />
          </div>
          <div className="row mt-3">
            <div className="col-2">
              <Link
                className="btn btn-primary w-100"
                to={`/house/edit/${data.id}`}
              >
                Edit
              </Link>
            </div>
            <div className="col-2">
              <button
                className="btn btn-danger w-100"
                onClick={() => {
                  if (window.confirm('Are you sure?'))
                    deleteHouseMutation.mutate(data)
                }}
              >
                Delete
              </button>
            </div>
          </div>
        </div>
        <div className="col-6">
          <div className="row mt-2">
            <h5 className="col-12">{data.country}</h5>
          </div>
          <div className="row">
            <h3 className="col-12">{data.address}</h3>
          </div>
          <div className="row">
            <h2 className="themeFontColor col-12">
              ${data.price.toLocaleString('en-us')}
            </h2>
          </div>
          <div className="row">
            <div className="col-12 mt-3">{data.description}</div>
          </div>
          <Bids house={data} />
        </div>
      </div>
    </>
  )
}

export default HouseDetail
